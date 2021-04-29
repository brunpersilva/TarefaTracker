import {ITarefa} from '../components/interfaces/interface'
import Tarefa from './tarefa'

const Tarefas = (props: any) => {
    return(
    <div>         
          
        <ul className="list-group">

          {props.map((todo : ITarefa) =>             
          Tarefa(todo))}
          

        </ul>
    </div>
    )
}

export default Tarefas;