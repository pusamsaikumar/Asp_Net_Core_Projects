import logo from './logo.svg';
import './App.css';
import Login from './components/Login';
import Registration from './components/Registration';
import {BrowserRouter, Routes,Route} from "react-router-dom";
import RouterPage from './components/RouterPage';

function App() {
  return (
<div>
  <RouterPage />
</div>
  );
}

export default App;
