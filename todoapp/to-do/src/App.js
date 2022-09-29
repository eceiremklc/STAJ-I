import React from 'react';
import './App.css';
import TodoForm from './Components/TodoForm';
import TodoList from './Components/TodoList';

function App() {
  return (
    <div className="to-do-app">
      <TodoList/>
    </div>
  );
}

export default App;
