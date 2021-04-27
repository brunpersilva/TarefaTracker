import React, {Component} from 'react';
import './App.css';
import axios from 'axios';
import Loading from './components/loading';
import Tarefas from './components/tarefa';
import { ITarefa } from './components/interfaces/interfaces';

class App extends Component{
  state = {tarefas: [] };
 async componentDidMount(){
    let result = await axios.get('https://localhost:44377/api/tarefas/GetAllTarefas');
    this.setState({tarefas: result.data});

}
  render(){
  return(
    <div className='container'>
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
    </div>  
  );
  }
}

export default App;