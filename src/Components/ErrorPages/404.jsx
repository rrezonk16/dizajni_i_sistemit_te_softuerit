import React from 'react'
import Navbar from '../Navigation/Navbar'
import Footer from '../Navigation/Footer'

const Error404 = () => {
  return (

    <div className='flex flex-col justify-between'> 
        <Navbar/>
        <div className="flex flex-grow items-center justify-center bg-gray-100 py-8">
            <div className="bg-white p-8 rounded-lg my-32 shadow-md w-full max-w-sm">
                <h1 className="text-2xl font-semibold mb-6 text-center">Error 404</h1>
                <p className="text-xl font-semibold mb-6 text-center">Page not found</p>
            </div></div>
            <Footer/>
    </div>
  )
}

export default Error404