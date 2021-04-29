import React from 'react';
import {ITarefa} from '../components/interfaces/interface'

const Tarefa = (props : ITarefa) => {
    return(     
        <li key= {props.id} className="list-group-item list-group-item-action active">
          
            <h3>{props.titulo}</h3>
            <p>Descrição: {props.descricao}</p>
            <input type = "checkbox" checked ={true}/>
            <button type="button" className="btn btn-secondary">Editar</button>
            <button type="button" className="btn btn-danger">Excluir</button>    
            </li>   
    )
};

export default Tarefa;