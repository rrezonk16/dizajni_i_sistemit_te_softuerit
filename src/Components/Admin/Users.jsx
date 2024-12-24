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
        <div>
            User Component
        </div>
    )
}

export default Users