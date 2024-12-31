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
    <div className="bg-gradient-to-r from-blue-200 to-purple-500 min-h-screen flex flex-col">
      <Navbar />
      <div className="flex items-center justify-center flex-grow">
        <div className="bg-white p-10 rounded-xl shadow-2xl max-w-4xl w-full text-center transform transition-all hover:scale-105 hover:shadow-2xl">
          <h1 className="text-5xl font-semibold text-gray-900 mb-6 tracking-tight">
            Welcome to the Restaurant Management System!
          </h1>
          <p className="text-xl text-gray-600 mb-8">
            This platform helps you efficiently manage various aspects of your restaurant. Here's what you can do:
          </p>
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6 mb-8">
            <div className="flex items-start space-x-3">
              <span className="text-3xl text-blue-600">&#x2705;</span>
              <p className="text-lg text-gray-700">Manage Reservations & Orders</p>
            </div>
            <div className="flex items-start space-x-3">
              <span className="text-3xl text-green-600">&#x1F464;</span>
              <p className="text-lg text-gray-700">Track Employee Schedules</p>
            </div>
            <div className="flex items-start space-x-3">
              <span className="text-3xl text-yellow-500">&#x1F4C4;</span>
              <p className="text-lg text-gray-700">Handle Menus & Tables</p>
            </div>
            <div className="flex items-start space-x-3">
              <span className="text-3xl text-red-500">&#x1F4B0;</span>
              <p className="text-lg text-gray-700">Generate Invoices & Reports</p>
            </div>
          </div>
          <p className="text-lg text-gray-500">
            Navigate through the options in the menu above, and take advantage of all the features to streamline your restaurant management. 
            Admin users will have access to advanced settings and control features.
          </p>
        </div>
      </div>
    </div>
  );
};

  export default Main