import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Main from "./Components/Main";


const routes = [
  {
    path: "/",
    element: <Main/>
  },

];
function App() {
  
  return (
    <Router>

      <div className="App">

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