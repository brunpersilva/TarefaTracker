import React from 'react';
import axios from 'axios';
import Loading from './components/loading';
import Tarefas from './components/tarefas';
import {ThemeProvider} from 'styled-components'
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