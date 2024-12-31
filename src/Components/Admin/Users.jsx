import React, { useEffect, useState } from 'react';
import { checkPermission } from '../../Functions/checkPermission';
import { useNavigate } from 'react-router-dom';

const Users = () => {
    const navigate = useNavigate();
    const [hasPermission, setHasPermission] = useState(true);
    const [showModal, setShowModal] = useState(false);
    const [formData, setFormData] = useState({
        Name: '',
        Surname: '',
        Email: '',
        PasswordHash: '',
        PhoneNumber: '',
        Address: '',
    });

    useEffect(() => {
        if (!checkPermission('READ_USERS')) {
            setHasPermission(false);
            navigate('/admin');
        }
    }, [navigate]);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log('Form Data Submitted:', formData);
        // Add API call here to submit formData to the backend
        setShowModal(false);
        setFormData({
            Name: '',
            Surname: '',
            Email: '',
            PasswordHash: '',
            PhoneNumber: '',
            Address: '',
        });
    };

    if (!hasPermission) {
        return null;
    }

    return (
        <div className="container mx-auto px-4 sm:px-8 mt-8">
            <div className="flex justify-between items-center mb-4">
                <h1 className="text-2xl font-semibold text-gray-700">User Management</h1>
                {checkPermission("CREATE_USERS") && (
                    <button
                        onClick={() => setShowModal(true)}
                        className="bg-blue-600 text-white px-4 py-2 rounded shadow hover:bg-blue-700 transition duration-200"
                    >
                        Add User
                    </button>
                )}
            </div>
            <div className="relative overflow-x-auto shadow-md">
                <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <thead className="text-xs text-gray-700 uppercase bg-gray-200">
                        <tr>
                            <th scope="col" className="px-6 py-3">Name</th>
                            <th scope="col" className="px-6 py-3">Surname</th>
                            <th scope="col" className="px-6 py-3">Email</th>
                            <th scope="col" className="px-6 py-3">Role</th>
                            <th scope="col" className="px-6 py-3">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">Rrezon</th>
                            <td className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">Krasniqi</td>
                            <td className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">rrezonkrasniqi32@gmail.com</td>
                            <td className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap">Admin</td>
                            <td className="px-6 py-4">
                                {checkPermission("EDIT_USERS") && (
                                    <a href="/" className="font-medium text-blue-600 hover:underline">Edit</a>
                                )}
                                {checkPermission("DELETE_ITEM") && (
                                    <a href="/" className="font-medium ml-3 text-red-600 hover:underline">Delete</a>
                                )}
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            {showModal && (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
        <div className="bg-white rounded-lg shadow-lg w-full max-w-lg p-6 relative">
            <button
                onClick={() => setShowModal(false)}
                className="absolute top-2 right-2 text-gray-500 hover:text-gray-700"
                aria-label="Close"
            >
                <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                    strokeWidth="2"
                    stroke="currentColor"
                    className="w-6 h-6"
                >
                    <path
                        strokeLinecap="round"
                        strokeLinejoin="round"
                        d="M6 18L18 6M6 6l12 12"
                    />
                </svg>
            </button>
            <h2 className="text-2xl font-bold text-gray-800 mb-6 text-center">
                Add New User
            </h2>
            <form onSubmit={handleSubmit} className="space-y-4">
                <div>
                    <label className="block text-sm font-medium text-gray-700 mb-1">
                        Name
                    </label>
                    <input
                        type="text"
                        name="Name"
                        value={formData.Name}
                        onChange={handleInputChange}
                        className="w-full border rounded-lg px-3 py-2 text-gray-700 focus:ring-2 focus:ring-blue-500 focus:outline-none"
                        placeholder="Enter user's name"
                        required
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium text-gray-700 mb-1">
                        Surname
                    </label>
                    <input
                        type="text"
                        name="Surname"
                        value={formData.Surname}
                        onChange={handleInputChange}
                        className="w-full border rounded-lg px-3 py-2 text-gray-700 focus:ring-2 focus:ring-blue-500 focus:outline-none"
                        placeholder="Enter user's surname"
                        required
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium text-gray-700 mb-1">
                        Email
                    </label>
                    <input
                        type="email"
                        name="Email"
                        value={formData.Email}
                        onChange={handleInputChange}
                        className="w-full border rounded-lg px-3 py-2 text-gray-700 focus:ring-2 focus:ring-blue-500 focus:outline-none"
                        placeholder="Enter user's email"
                        required
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium text-gray-700 mb-1">
                        Password
                    </label>
                    <input
                        type="password"
                        name="PasswordHash"
                        value={formData.PasswordHash}
                        onChange={handleInputChange}
                        className="w-full border rounded-lg px-3 py-2 text-gray-700 focus:ring-2 focus:ring-blue-500 focus:outline-none"
                        placeholder="Enter a secure password"
                        required
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium text-gray-700 mb-1">
                        Phone Number
                    </label>
                    <input
                        type="text"
                        name="PhoneNumber"
                        value={formData.PhoneNumber}
                        onChange={handleInputChange}
                        className="w-full border rounded-lg px-3 py-2 text-gray-700 focus:ring-2 focus:ring-blue-500 focus:outline-none"
                        placeholder="Enter phone number"
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium text-gray-700 mb-1">
                        Address
                    </label>
                    <textarea
                        name="Address"
                        value={formData.Address}
                        onChange={handleInputChange}
                        className="w-full border rounded-lg px-3 py-2 text-gray-700 focus:ring-2 focus:ring-blue-500 focus:outline-none"
                        placeholder="Enter user's address"
                    />
                </div>
                <div className="flex justify-end space-x-3">
                    <button
                        type="button"
                        onClick={() => setShowModal(false)}
                        className="bg-gray-500 text-white px-4 py-2 rounded-lg shadow-md hover:bg-gray-600 transition duration-200"
                    >
                        Cancel
                    </button>
                    <button
                        type="submit"
                        className="bg-blue-600 text-white px-4 py-2 rounded-lg shadow-md hover:bg-blue-700 transition duration-200"
                    >
                        Add User
                    </button>
                </div>
            </form>
        </div>
    </div>
)}

        </div>
    );
};

export default Users;
