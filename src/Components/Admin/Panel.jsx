import React, { useEffect, useState } from 'react'
import Navbar from '../Navigation/Navbar'
import Stock from './Stock';
import Users from './Users';
import Orders from './Orders';
import Products from './Products';
import Reports from './Reports';
import Welcome from './Welcome';

const Panel = () => {
  const [component, setComponent] = useState(null);

  useEffect(() => {
    const urlParams = new URLSearchParams(window.location.search);
    const readParam = urlParams.get('read');
    switch (readParam) {
      case 'users':
        setComponent(<UsersComponent />);
        break;
      case 'products':
        setComponent(<ProductsComponent />);
        break;
      case 'orders':
        setComponent(<OrdersComponent />);
        break;
      case 'stock':
        setComponent(<StockComponent />);
        break;
      case 'reports':
        setComponent(<ReportsComponent />);
        break;
      default:
        setComponent(<DefaultComponent />);
        break;
    }
  }, []);

  return (
    <div>
      <Navbar />
      {component}
    </div>
  )
}

const UsersComponent = () => <Users/>;
const ProductsComponent = () => <Products/>;
const OrdersComponent = () => <Orders/>;
const StockComponent = () => <Stock/>;
const ReportsComponent = () =><Reports/>;
const DefaultComponent = () => <Welcome/>;

export default Panel