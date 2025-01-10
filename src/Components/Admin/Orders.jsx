import React, { useEffect, useState } from 'react'
import { checkPermission } from '../../Functions/checkPermission'
import { useNavigate } from 'react-router-dom'
  
const Orders = () => {
    const navigate = useNavigate();
    const [hasPermission, setHasPermission] = useState(true);

    useEffect(() => {
        if (!checkPermission('READ_ORDERS')) {
            setHasPermission(false);
            navigate('/admin');
        }
    }, [navigate]);

    if (!hasPermission) {
        return null;
    }

    return (
        <div>
            Orders Component
        </div>
    )
}

export default Orders