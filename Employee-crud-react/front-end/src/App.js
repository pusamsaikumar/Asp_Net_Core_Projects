import logo from './logo.svg';
import './App.css';
import { NavLink ,Nav,Navbar ,Container} from 'react-bootstrap';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './components/Home';
import Department from './components/Department';
import Employee from './components/Employee';
function App() {
  return (
    <div className="App">
       <h3 className='d-flex justify-content-center m-3'>React js Frontend</h3>
      


       <Navbar expand="lg" className="bg-body-tertiary">
      <Container>
        
     
   
          <Nav className="mr-5">
            <Nav.Link href="/home"  className='btn btn-light btn-outline-lightgrey mr-10' style={{marginRight:"10px"}}>Home</Nav.Link>
            <Nav.Link href='/department'  className='btn btn-light btn-outline-lightgrey mr-10' style={{marginRight:"10px"}}>Department</Nav.Link>
            <Nav.Link href="/employee"  className='btn btn-light btn-outline-lightgrey mr-10'style={{marginRight:"10px"}}>Employee</Nav.Link>
       
          </Nav>
      
      </Container>
    </Navbar>

       <BrowserRouter>
          <Routes>
            <Route path='/home' element={<Home />} />
            <Route path='/department' element={<Department />} />
            <Route path='/employee' element={<Employee />} />
          </Routes>
       </BrowserRouter>
    </div>
  );
}

export default App;
