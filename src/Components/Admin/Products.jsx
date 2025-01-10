import React, { useEffect, useState } from 'react'
import { checkPermission } from '../../Functions/checkPermission'
import { useNavigate } from 'react-router-dom'
  
const Products = () => {
    const navigate = useNavigate();
    const [hasPermission, setHasPermission] = useState(true);

    useEffect(() => {
        if (!checkPermission('READ_PRODUCTS')) {
            setHasPermission(false);
            navigate('/admin');
        }
    }, [navigate]);

    if (!hasPermission) {
        return null;
    }

    return (
        <div>
            Products Component
        </div>
    )
}

export default Products