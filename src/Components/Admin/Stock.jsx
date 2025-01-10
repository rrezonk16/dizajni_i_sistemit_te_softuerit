import React, { useEffect, useState } from 'react'
import { checkPermission } from '../../Functions/checkPermission'
import { useNavigate } from 'react-router-dom'
  
const Stock = () => {
    const navigate = useNavigate();
    const [hasPermission, setHasPermission] = useState(true);

    useEffect(() => {
        if (!checkPermission('READ_STOCK')) {
            setHasPermission(false);
            navigate('/admin');
        }
    }, [navigate]);

    if (!hasPermission) {
        return null;
    }

    return (
        <div>
            Stock Component
        </div>
    )
}

export default Stock