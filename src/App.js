import React, { Suspense, lazy } from 'react';
import { Routes, Route } from 'react-router-dom';
import Navbar from './Components/Navigation/Navbar';
import Footer from './Components/Navigation/Footer';
import { ClientProvider } from './Contexts/ClientContext';
import { ReservationProvider } from './Contexts/ReservationContext';
import ProductList from "./Components/Products/ProductList";
import Error404 from "./Components/ErrorPages/404";
import Panel from "./Components/Admin/Panel";
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const ClientList = lazy(() => import('./Components/Clients/ClientList'));
const CreateClient = lazy(() => import('./Components/Clients/CreateClient'));
const EditClient = lazy(() => import('./Components/Clients/EditClient'));
const ReservationList = lazy(() => import('./Components/Reservations/ReservationList'));
const CreateReservation = lazy(() => import('./Components/Reservations/CreateReservation'));
const ReservationSuccess = lazy(() => import('./Components/Reservations/ReservationSuccess'));
const ReservationDetails = lazy(() => import('./Components/Reservations/ReservationDetails')); 
const Main = lazy(() => import('./Components/Main'));
const Login = lazy(() => import('./Components/Authentication/Login'));
const Register = lazy(() => import('./Components/Authentication/Register'));

const routes = [
  { path: "/", element: <Main /> },
  { path: "/login", element: <Login /> },
  { path: "/register", element: <Register /> },
  { path: "/products", element: <ProductList /> },
  { path: "/admin", element: <Panel /> },
  { path: "/clients", element: <ClientList /> },
  { path: "/create-client", element: <CreateClient /> },
  { path: "/clients/edit/:clientId", element: <EditClient /> },
  { path: "/reservations", element: <ReservationList /> },
  { path: "/create-reservation", element: <CreateReservation /> },
  { path: "/reservation-success/:secretId", element: <ReservationSuccess /> }, 
  { path: "/reservation-details/:secretId", element: <ReservationDetails /> },
  { path: "*", element: <Error404 /> }
];

function App() {
  return (
    <ReservationProvider>
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
        <ToastContainer />
      </ClientProvider>
    </ReservationProvider>
  );
}

export default App;
