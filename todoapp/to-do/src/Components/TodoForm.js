import React, {useEffect, useState, useRef} from 'react'

function TodoForm(props) {
    const[input, setInput]=useState(props.edit ? props.edit.value : '');

    const inputRef = useRef(null);

    useEffect(()=>{
        inputRef.current.focus();
    });

    const handleChange = e =>{
        setInput(e.target.value);
    };

    const handleSubmit = e=>{
        e.preventDefault();

        props.onSubmit({
            id: Math.floor(Math.random()*10000),
            text: input
        });

        setInput('');
    };

  return (
    <form className='todo-form' onSubmit={handleSubmit}>
        {props.edit ? (
        <>
          <input
            placeholder='Maddeni güncelle'
            value={input}
            onChange={handleChange}
            name='text'
            ref={inputRef}
            className='todo-input edit'
          />
          <button onClick={handleSubmit} className='todo-button edit'>
            Güncelle
          </button>
        </>
      ) : (
        <>
          <input
            placeholder='Yapılacaklar listene bir madde ekle!'
            value={input}
            onChange={handleChange}
            name='text'
            className='todo-input'
            ref={inputRef}
          />
          <button onClick={handleSubmit} className='todo-button'>
            Ekle
          </button>
        </>
      )}
    </form>
  );
}

export default TodoForm;
