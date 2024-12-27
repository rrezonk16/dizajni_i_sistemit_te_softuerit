import React, { useEffect } from 'react';
import { isLoggedIn } from '../Functions/isLoggedIn';
import { useNavigate } from 'react-router-dom';
import Navbar from './Navigation/Navbar';



  const Main = () => {
    const navigate = useNavigate();

  useEffect(() => {
    if (!isLoggedIn()) {
      navigate('/login'); 
    }
  }, [navigate]);

  return (
    <div className='bg-slate-400'>
      <Navbar />
    </div>
  );
};

  export default Main