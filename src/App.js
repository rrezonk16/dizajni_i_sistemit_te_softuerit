import React, { Suspense, lazy } from 'react';
import { Routes, Route } from 'react-router-dom';
import Navbar from './Components/Navigation/Navbar';
import Footer from './Components/Navigation/Footer';
import { ClientProvider } from './Contexts/ClientContext';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Main from "./Components/Main";
import Login from "./Components/Authentication/Login";
import Register from "./Components/Authentication/Register";
import ProductList from "./Components/Products/ProductList";
import Error404 from "./Components/ErrorPages/404";
import Panel from "./Components/Admin/Panel";

const Main = lazy(() => import('./Components/Main'));
const Login = lazy(() => import('./Components/Authentication/Login'));
const Register = lazy(() => import('./Components/Authentication/Register'));
const ClientList = lazy(() => import('./Components/ClientList'));
const CreateClient = lazy(() => import('./Components/CreateClient'));
const EditClient = lazy(() => import('./Components/EditClient'));

const routes = [
  {
    path: "/",
    element: <Main/>
  },
  {
    path: "/login",
    element: <Login/>
  },
  {
    path: "/products",
    element: <ProductList/>
  },
  {
    path: "/register",
    element: <Register/>
  },
  {
    path: "/admin",
    element: <Panel/>
  },
  {
    path: "/*",
    element: <Error404/>
  },
  { path: '/clients', element: <ClientList /> },
  { path: '/create-client', element: <CreateClient /> },
  { path: '/clients/edit/:clientId', element: <EditClient /> },
];

function App() {
  return (
    <ClientProvider>
      <div className="flex flex-col min-h-screen">
        <Navbar />
        <div className="flex-grow">
          <Suspense fallback={<div>Loading...</div>}>
            <Routes>
              {routes.map((route, index) => (
                <Route key={index} path={route.path} element={route.element} />
              ))}
            </Routes>
          </Suspense>
        </div>
        <Footer />
      </div>
    </ClientProvider>
  );
}

export default App;