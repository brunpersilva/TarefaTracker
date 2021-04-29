import React from 'react';
import axios from 'axios';
import Loading from './components/loading';
import Tarefas from './components/tarefas';
import {ThemeProvider} from 'styled-components'
//import { IPage, ITarefa } from './components/interfaces/interface';
import Paginacao from './components/paginacao';
import GlobalStyles from './styles/GlobalStyles'
import DashBoard from './pages/Dashboard';
import Layout from './components/Layout';
import dark from './styles/themes/dark';


const App: React.FC = () => {

  return(
          <ThemeProvider theme={dark}>
            <GlobalStyles/>
            <Layout/>
          </ThemeProvider>
     
  );
}

export default App;


//const page:IPage = {pageSize: 5, currentIndex: 1, lastRecord: 0};

// const App: React.FC =() => {
// //   state = {tarefas:[]};
     
// //  async componentDidMount(){
// //     let result = await axios.post('https://localhost:44377/api/tarefas/GetAllTarefas', {page});
// //     this.setState({tarefas: result.data.tarefas});
// //     console.log(result);

// // }
// //   render(){
//   return(
//     <GlobalStyles>
//       <DashBoard/>
//     </GlobalStyles>
    
    // <div className='container'>

    //  <nav className="navbar navbar-light bg-light">
    //    <h1>Lista de Tarefas</h1>   
    //   <button type="button" className="btn btn-primary">Adcionar Tarefa</button>
      
    // </nav>
    //     {this.state.tarefas.length > 0 ? (

    //     Tarefas(this.state.tarefas) 
                      
    //     ) : (
    //     <Loading />
    //     )}
    //     <Paginacao/>
    // </div>
//   );
// }
  


