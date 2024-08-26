interface Props {
    id: number,
    name: string;
    surname: string;
}

export const CardTitle = ({name, surname, id}: Props) =>{
    return (
        <div>
            <p className="card__id">№ {id}</p>
            <p className="card__name">Name: {name}</p>
            <p className="card__surname">Surname: {surname}</p>
        </div>
    )
}