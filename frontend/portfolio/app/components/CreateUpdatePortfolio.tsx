import Modal from "antd/es/modal/Modal";
import { PortfolioRequest } from "../services/portfolios";
import Input from "antd/es/input/Input";
import { useEffect, useState } from "react";
import TextArea from "antd/es/input/TextArea";

interface Props {
    mode: Mode;
    values: Portfolio;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: PortfolioRequest) => void;
    handleUpdate: (id: number, request: PortfolioRequest) => void;
}

export enum Mode {
    Create,
    Edit
}

export const CreateUpdatePortfolio = ({mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,}: Props) => {
        const [name, setName] = useState<string>("");
        const [surname, setSurname] = useState<string>("");
        const [description, setDescription] = useState<string>("");

        useEffect(()=>{
            setName(values.name)
            setSurname(values.surname)
            setDescription(values.description)
        }, [values])

        const handleOnOk = async ()=>{
            const portfolioRequest = {name, surname, description };
            mode == Mode.Create 
                ? handleCreate(portfolioRequest) 
                : handleUpdate(values.id, portfolioRequest)
        }
        
        return (
            <Modal 
                title={mode === Mode.Create ? "Add portfolio" : "Edit portfolio" } 
                open={isModalOpen} 
                cancelText={"Cancel"}
                onOk={handleOnOk}
                onCancel={handleCancel}

            >

                <div className="book__modal">
                    <Input
                        value={name}
                        onChange={(e)=> setName(e.target.value)}
                        placeholder="Name"
                     />  
                      <Input
                        value={surname}
                        onChange={(e)=> setSurname(e.target.value)}
                        placeholder="Surname"
                     />  
                     <TextArea
                        value={description}
                        onChange={(e)=> setDescription(e.target.value)}
                        placeholder="Description"
                     />
                </div>
            </Modal>
        )
    };