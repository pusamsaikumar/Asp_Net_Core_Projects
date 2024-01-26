import React from 'react';
import {BrowserRouter as Router , Routes, Route} from "react-router-dom";
import Login from './Login';
import Registration from './Registration';
import Dashboard from './Users/Dashboard';
import Orders from './Users/Orders';
import Profile from './Users/Profile';
import Cart from './Users/Cart';
import MedicineDisplay from './Users/MedicineDisplay';
import AdminDashboard from './AdminDashboard';
import AdminOrder from './Admin/AdminOrder';
import CustomerList from './Admin/CustomerList';
import Medicine from './Admin/Medicine';
import UserDashboard from './UserDashboard';
import RegistrationList from './RegistrationList';
import ArticleList from './ArticleList';
import NewsList from './NewsList';
import StaffList from './StaffList';
import UserArticleList from './UserArticle';
import UserNews from './UserNews';


 
const RouterPage = () => {
  return (
    <Router>
       <Routes>
            {/* for User */}
            <Route path='/' element={<Login />} />
            <Route path='/registration' element={<Registration />} />
            <Route path='/admindashboard' element={<AdminDashboard />} />
            <Route path ='/userdashboard' element={<UserDashboard />} />
            <Route path='/registrationlist' element={<RegistrationList />} />
            <Route path='/articlelist' element={<ArticleList />} />
            <Route path='/newslist' element={<NewsList />} />
            <Route path='/stafflist' element={<StaffList />} />
            <Route path='/userarticle' element={<UserArticleList />} />
            <Route path='/usernews' element={<UserNews />} />
           

           
       </Routes>
    </Router>
  )
}

export default RouterPage
