import React from 'react';
import { isLoggedIn } from '../Functions/isLoggedIn';
import { useNavigate } from 'react-router-dom';

const Main = () => {
  const navigate = useNavigate();

  if (!isLoggedIn()) {
    navigate('/login'); 
  }

  return (
    <div className='bg-slate-400'>
      <h1 className="text-center text-2xl font-bold">Welcome to the Main Page</h1>
    </div>
  );
}

export default Main;
