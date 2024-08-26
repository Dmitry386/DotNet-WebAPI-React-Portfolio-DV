export interface PortfolioRequest{
    name: string;
    surname: string;
    description: string;
}

export const getAllPortfolios = async () => {
    const response = await fetch("http://localhost:5231/Portfolios");

    return response.json();
}

export const createPortfolio = async (portfolioRequest: PortfolioRequest) => {
    const response = await fetch("http://localhost:5231/Portfolios", {
        method: "POST",
        headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify(portfolioRequest),
    });
    
    return response.json();
}

export const updatePortfolio = async (id: number, portfolioRequest: PortfolioRequest) => {
    await fetch(`http://localhost:5231/Portfolios/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify(portfolioRequest),
    });
}

export const deletePortfolio= async (id: number) => {
    await fetch(`http://localhost:5231/Portfolios/${id}`, {
        method: "DELETE"
    }); 
}