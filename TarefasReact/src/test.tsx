import React from 'react';
import axios, { CancelTokenSource } from 'axios';

interface IPost {
  id: number;
  titulo: String;
  descricao: String;
}

const defaultPosts: IPost[] = [];

const App = () => {
  const [posts, setPosts]: [IPost[], (posts: IPost[]) => void] = React.useState(
    defaultPosts
  );

  const [loading, setLoading]: [
    boolean,
    (loading: boolean) => void
  ] = React.useState<boolean>(true);

  const [error, setError]: [string, (error: string) => void] = React.useState(
    ''
  );

  const cancelToken = axios.CancelToken; //create cancel token
  const [cancelTokenSource, setCancelTokenSource]: [
    CancelTokenSource,
    (cancelTokenSource: CancelTokenSource) => void
  ] = React.useState(cancelToken.source());

  const handleCancelClick = () => {
    if (cancelTokenSource) {
      cancelTokenSource.cancel('User cancelled operation');
    }
  };

  React.useEffect(() => {
    axios
      .get<IPost[]>('https://localhost:44377/api/tarefas/GetAllTarefas', {
        cancelToken: cancelTokenSource.token,
        headers: {
          'Content-Type': 'application/json',
        },
        timeout: 10000,
      })
      .then((response) => {
        setPosts(response.data);
        setLoading(false);
      })
      .catch((ex) => {
        let error = axios.isCancel(ex)
          ? 'Request Cancelled'
          : ex.code === 'ECONNABORTED'
          ? 'A timeout has occurred'
          : ex.response.status === 404
          ? 'Resource Not Found'
          : 'An unexpected error has occurred';

        setError(error);
        setLoading(false);
      });
  }, []);

  return (
    <div className="App">
      {loading && <button onClick={handleCancelClick}>Cancel</button>}
      <ul className="posts">
        {posts.map((post) => (
          <li key={post.id}>
            <h1> ID: {post.id}</h1>
            <h2> Titulo: {post.titulo}</h2>
            <p> Descrição: {post.descricao}</p>
          </li>
        ))}
      </ul>
      {error && <p className="error">{error}</p>}
    </div>
  );
};

export default App;