import React, { useEffect, useState } from 'react'
import { checkPermission } from '../../Functions/checkPermission'
import { useNavigate } from 'react-router-dom'
  
const Reports = () => {
    const navigate = useNavigate();
    const [hasPermission, setHasPermission] = useState(true);

    useEffect(() => {
        if (!checkPermission('READ_REPORTS')) {
            setHasPermission(false);
            navigate('/admin');
        }
    }, [navigate]);

    if (!hasPermission) {
        return null;
    }

    return (
        <div>
            Reports Component
        </div>
    )
}

export default Reports