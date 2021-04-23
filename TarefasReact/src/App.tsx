import React from 'react';
import logo from './logo.svg';
import './App.css';
import axios, { CancelTokenSource } from 'axios';

interface IPost {
  id: number;
  titulo: string;
  descricao: string;
}

const defaultPosts:IPost[] = [];

const App = () => {
  const [posts, setPosts]: [IPost[], (posts: IPost[]) => void] = React.useState(defaultPosts);
  const [loading, setLoading]: [boolean, (loading: boolean) => void] = React.useState<boolean>(true);
  const [error, setError]: [string, (error: string) => void] = React.useState("");
  const cancelToken = axios.CancelToken; 
  const [cancelTokenSource, setCancelTokenSource]: [CancelTokenSource,(cancelTokenSource: CancelTokenSource) => void] = React.useState(cancelToken.source());
  
  React.useEffect(() => {
    axios
        .get<IPost[]>("https://localhost:44377/api/tarefas/GetTarefas/3", {
          headers: {
            "Content-Type": "application/json"
          },
          timeout: 1000   
        })
        .then(response => {
          setPosts(response.data);
          setLoading(false);
        })
        .catch(ex => {
          const error =
          ex.code === "ECONNABORTED"
          ? "A timeout has occurred"
          : ex.response.status === 404           
          ? "Resource Not found"
          : "An unexpected error has occurred";
          setError(error);
          setLoading(false);
          
        });
    }, []);


    return (
      <div className="App">
       <ul className="posts">
         {posts.map((post) => (
          <li key={post.id}>
           <h3>{post.titulo}</h3>
           <p>{post.descricao}</p>
          </li>
        ))}
       </ul>
       {error && <p className="error">{error}</p>}
     </div>
     );
  
}








export default App;
