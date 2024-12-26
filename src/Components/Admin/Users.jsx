import React, { useEffect, useState } from 'react'
import { checkPermission } from '../../Functions/checkPermission'
import { useNavigate } from 'react-router-dom'

const Users = () => {
    const navigate = useNavigate();
    const [hasPermission, setHasPermission] = useState(true);

    useEffect(() => {
        if (!checkPermission('READ_USERS')) {
            setHasPermission(false);
            navigate('/admin');
        }
    }, [navigate]);

    if (!hasPermission) {
        return null;
    }

    return (
        <div className="container mx-auto px-4 sm:px-8 mt-8">
            <div className="relative overflow-x-auto shadow-md">
                <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <thead className="text-xs text-gray-700 uppercase bg-gray-200 ">
                        <tr>
                            <th scope="col" className="px-6 py-3">
                                Name
                            </th>
                            <th scope="col" className="px-6 py-3">
                                Surname
                            </th>
                            <th scope="col" className="px-6 py-3">
                                Email
                            </th>
                            <th scope="col" className="px-6 py-3">
                                Role
                            </th>
                            <th scope="col" className="px-6 py-3">
                                Action
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr className=" ">
                            <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap ">
                                Rrezon
                            </th>
                            <td className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap ">
                                Krasniqi
                            </td>
                            <td className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap ">
                                rrezonkrasniqi32@gmail.com
                            </td>
                            <td className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap ">
                                Admin
                            </td>
                            <td className="px-6 py-4">
                                {checkPermission("EDIT_USERS") && (<a href="/" className="font-medium text-blue-600 hover:underline">Edit</a>)}
                                {checkPermission("DELETE_ITEM") && (<a href="/" className="font-medium ml-3 text-red-600  hover:underline">Delete</a>)}

                            </td>
                        </tr>
                                      
                    </tbody>
                </table>
            </div>

        </div>
    )
}

export default Users