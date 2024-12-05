import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Main from "./Components/Main";
import Login from "./Components/Authentication/Login";
import Register from "./Components/Authentication/Register";


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
    path: "/register",
    element: <Register/>
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