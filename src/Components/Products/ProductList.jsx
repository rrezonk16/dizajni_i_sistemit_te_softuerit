import React from 'react'
import { checkPermission } from '../../Functions/checkPermission';

if (checkPermission('EDIT_PRODUCTS')) {
  console.log('User can edit products');
}

const ProductList = () => {
  return (
    <div>ProductList</div>
  )
}

export default ProductList