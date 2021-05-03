import axios, { CancelTokenSource } from 'axios';
import {useState, useEffect, Component} from 'react';
import { IPage, ITarefa } from '../interfaces/interface';
import {Container, Form} from './style'
import Loading from '../loading';
import Tarefas from '../Tarefa/'

var page: any = { "ItensPorPagina": 3, "PaginaAtual":1}

class Content extends Component{
    state = {tarefas: [] };
   
   async componentDidMount(){
      let result = await axios.post('https://localhost:44377/api/tarefas/GetAllTarefas', page);
      this.setState({tarefas: result.data.tarefas});
      console.log(result.data);
  
  }
    render(){
    return(

      <Container className='container'>
          {this.state.tarefas.length > 0 ? (
            
          <div>
            
            <ul className="list-group">
  
              {this.state.tarefas.map((todo : ITarefa)=>             
              Tarefas(todo))}
  
            </ul>
            </div>
            
            
          ) : (
          <Loading />
          )}
      </Container>  
    );
    }
  }
  
  export default Content;