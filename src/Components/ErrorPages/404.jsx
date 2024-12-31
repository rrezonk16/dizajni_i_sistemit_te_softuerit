import React from 'react';
import Navbar from '../Navigation/Navbar';
import Footer from '../Navigation/Footer';
import notfound from './notfound.png';

const Error404 = () => {
  return (
    <div className="flex flex-col min-h-screen justify-between">
      <Navbar />
      <div className="flex flex-grow items-center justify-center bg-gray-100 py-8">
        <div className="bg-white p-8 rounded-lg shadow-md w-full max-w-4xl text-center flex flex-col md:flex-row items-center">
          {/* Image Section */}
          <div className="md:w-1/2 mb-6 md:mb-0">
            <img 
              src={notfound} 
              alt="404 illustration" 
              className="w-full h-auto"
            />
          </div>
          {/* Text Section */}
          <div className="md:w-1/2 md:pl-6">
            <h1 className="text-4xl font-bold text-red-600 mb-4">404 - Page Not Found</h1>
            <p className="text-lg text-gray-700 mb-6">
              Oops! The page you're looking for doesn't exist or has been moved.
            </p>
            <p className="text-gray-600 mb-4">
              This may have happened because:
            </p>
            <ul className="list-disc list-inside text-left text-gray-600 mb-6">
              <li>The URL you entered is incorrect.</li>
              <li>The page has been removed or renamed.</li>
              <li>You followed a broken or outdated link.</li>
            </ul>
            <p className="text-gray-600 mb-6">
              You can go back to the homepage or use the navigation menu to find what you're looking for.
            </p>
            <a 
              href="/" 
              className="text-white bg-blue-600 hover:bg-blue-700 px-6 py-3 rounded-full text-sm font-medium transition duration-200"
            >
              Go to Homepage
            </a>
          </div>
        </div>
      </div>
      <Footer />
    </div>
  );
};

export default Error404;
