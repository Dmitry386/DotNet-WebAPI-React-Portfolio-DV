import Card from "antd/es/card/Card";
import { CardTitle } from "./CardTitle";
import Button from "antd/es/button/button";

interface Props {
    portfolios: Portfolio[];
    handleDelete: (id: number)=>void;
    handleOpen: (portfolio: Portfolio)=>void;
}

export const Portfolios = ({ portfolios, handleDelete, handleOpen }: Props) => {
    return (
        <div className="cards">
            <br></br>
            {portfolios.map((portfolio : Portfolio) => (
                <Card  
                    key={portfolio.id} 
                    title={<CardTitle id={portfolio.id} name={portfolio.name} surname={portfolio.surname}/>}
                    bordered={true}
                    >
                        <p style={{whiteSpace: "pre"}} >Description: {portfolio.description}</p>
                        <div className="card__buttons">
                            <Button onClick={()=>handleOpen(portfolio)}
                                style={{flex: 1}}
                            >
                                Edit
                            </Button>

                            <Button onClick={()=>handleDelete(portfolio.id)}
                                danger
                                style={{flex: 1}}
                            >
                                Delete
                            </Button>
                        </div>
                    </Card>
            ))}
        </div>
    );
};