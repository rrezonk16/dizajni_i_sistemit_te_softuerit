import React, { useState } from "react";
import { Link } from "react-router-dom";

const Navbar = () => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <nav className="bg-gray-800">
      <div className="max-w-screen-xl px-4 py-2 mx-auto">
        <div className="flex items-center justify-between">
          <div className="flex items-center">
            <span className="text-white text-2xl font-semibold">Logo</span>
          </div>
          <button
            onClick={() => setIsOpen(!isOpen)}
            className="text-white md:hidden"
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              className="w-6 h-6"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="M4 6h16M4 12h16M4 18h16"
              />
            </svg>
          </button>
        </div>
        <div
          className={`${isOpen ? "block" : "hidden"} w-full md:block md:w-auto`}
          id="navbar-default"
        >
          <ul className="font-medium flex flex-col p-4 md:p-0 mt-4 border border-gray-100 rounded-lg bg-gray-50 md:flex-row md:space-x-8 md:mt-0 md:border-0 md:bg-gray-800 md:text-white dark:bg-gray-800 md:dark:bg-gray-900 dark:border-gray-700">
            <li>
              <Link to="/" className="block py-2 px-3 text-white md:hover:bg-transparent md:hover:text-blue-700 dark:text-white md:dark:hover:text-blue-500">
                Home
              </Link>
            </li>
            <li>
              <Link to="/about" className="block py-2 px-3 text-white md:hover:bg-transparent md:hover:text-blue-700 dark:text-white md:dark:hover:text-blue-500">
                About
              </Link>
            </li>
            <li>
              <Link to="/services" className="block py-2 px-3 text-white md:hover:bg-transparent md:hover:text-blue-700 dark:text-white md:dark:hover:text-blue-500">
                Services
              </Link>
            </li>
            <li>
              <Link to="/contact" className="block py-2 px-3 text-white md:hover:bg-transparent md:hover:text-blue-700 dark:text-white md:dark:hover:text-blue-500">
                Contact
              </Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
