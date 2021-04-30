import React from 'react';
import {ITarefa} from '../interfaces/interface'

const Tarefas = (props : ITarefa) => {
    return(     
        <li key= {props.id} className="list-group-item d-flex justify-content-between align-items-center">
            <h3>Titulo : {props.titulo}</h3>
            <p>Descrição: {props.descricao}</p>
            <span className="">              
              <input type = "checkbox" checked ={true}/>                
            </span>              
            </li>   
    )
};

export default Tarefas;