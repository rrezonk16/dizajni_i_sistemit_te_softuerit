import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Main from "./Components/Main";
import Login from "./Components/Authentication/Login";
import Register from "./Components/Authentication/Register";
import ProductList from "./Components/Products/ProductList";
import Error404 from "./Components/ErrorPages/404";
import Panel from "./Components/Admin/Panel";


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
];
function App() {
  
  return (
    <Router>

      <div className="">

        <Routes>
          {routes.map((route, index) => (
            <Route key={index} path={route.path} element={route.element} />
          ))}
        </Routes>
      </div>
    </Router>
  );
}

export default App;