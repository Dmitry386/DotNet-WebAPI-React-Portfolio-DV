"use client";

import { Button } from "antd/es/radio";
import { Portfolios } from "../components/Portfolios";
import { useEffect, useState } from "react";
import { createPortfolio, deletePortfolio, getAllPortfolios, PortfolioRequest, updatePortfolio } from "../services/portfolios"; 
import Title from "antd/es/skeleton/Title";
import { CreateUpdatePortfolio, Mode } from "../components/CreateUpdatePortfolio";

export default function PortfoliosPage() {
    const defaultValues = {
        name: "",
        surname: "",
        description: "",
    } as Portfolio;
    
    const [values, setValues] = useState<Portfolio>({
        name: "",
        surname: "",
        description: "",
    } as Portfolio)
    
    const [portfolios, setPortfolios] = useState<Portfolio[]>([]);
    const [loading, setLoading] = useState(true);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [mode, setMode] = useState(Mode.Create);   
    
    useEffect(()=>{
        const getPortfolios = async () =>{
            const portfolios = await getAllPortfolios();
            setLoading(false);
            setPortfolios(portfolios);
        };

        getPortfolios();
    }, [])

    const handleCreatePortfolio = async (request: PortfolioRequest) => {
        await createPortfolio(request);
        closeModal();

        const portfolios = await getAllPortfolios();
        setPortfolios(portfolios);
    }

    const handleUpdatePortfolio = async(id:number, request: PortfolioRequest) => {
        await updatePortfolio(id, request);
        closeModal();

        const portfolios = await getAllPortfolios();
        setPortfolios(portfolios);
    }

    const handleDeletePortfolio = async(id:number) => {
        await deletePortfolio(id); 
        closeModal();

        const portfolios = await getAllPortfolios();
        setPortfolios(portfolios);
    }


    const openModal = () => {
        setMode(Mode.Create);
        setIsModalOpen(true);
    }

    const closeModal = () => {
        setValues(defaultValues);
        setIsModalOpen(false);
    }

    const openEditMode = (portfolio: Portfolio) => {
        setMode(Mode.Edit);
        setValues(portfolio);
        setIsModalOpen(true);
    }
  
    return  (
        <div>
             <br/>
            <Button 
                onClick={openModal}
            > 
                 Add Portfolio
            </Button>

            <CreateUpdatePortfolio 
                mode={mode} 
                values={values} 
                isModalOpen={isModalOpen} 
                handleCreate={handleCreatePortfolio} 
                handleUpdate={handleUpdatePortfolio} 
                handleCancel={closeModal}
            />

            {loading ? (<Title>Loading...</Title>) : (
                <Portfolios portfolios={portfolios} 
                handleDelete={handleDeletePortfolio} 
                handleOpen={openEditMode}
            />)} 
             
        </div>
    )
  }
  