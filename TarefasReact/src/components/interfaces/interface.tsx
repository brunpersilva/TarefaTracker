import React from "react";

export interface TodoInterface{
    id: string;
    name: string;
    isCompleted: boolean;
}

export interface TodoFormInterface{
    todos: TodoInterface[];
    handleTodoCreate: (todo: TodoInterface) => void;    
}

export interface TodoListInterface{
    handleTodoUpdate: (event: React.ChangeEvent<HTMLInputElement>, id: string) => void;
    handleTodoRemove:  (id: string) => void;
    handleTodoComplete:  (id: string) => void;
    todos: TodoInterface[]
}

export interface TodoItemInterface{
    handleTodoUpdate: (event: React.ChangeEvent<HTMLInputElement>, id: string) => void;
    handleTodoRemove:  (id: string) => void;
    handleTodoComplete:  (id: string) => void;
    todo: TodoInterface;
}

export interface ITarefa{
    id: number;
    titulo: String;
    descricao: String;
}

export interface ITarefas{
    tarefas: ITarefa[];
}

export interface IPage {
    pageSize: number;
    currentIndex: number;
    lastRecord: number;
  }
