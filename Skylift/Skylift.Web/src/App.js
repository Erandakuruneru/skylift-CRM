import React from 'react';
import {Route,BrowserRouter as Router } from 'react-router-dom';
import Header from './components/header/Header';
import HomePage from './components/home/HomePage';
import Contact from './components/contact/Contact';
import AboutUs from './components/aboutUs/AboutUs';
import Footer from './components/footer/Footer';
import TrackAndTrace from './components/sideBar/TrackAndTrace';
import RequestQuote from './components/sideBar/RequestQuote';
import ChooseUs from './components/chooseUs/ChooseUs';
import SupplyChainSolutions from './components/solutions/SupplyChainSolutions';
import WarehouseSolutions from './components/solutions/WarehouseSolutions';
import Search from './components/search/Search';
import Test from './components/aboutUs/Test';
import PrivacyPolicy from './components/footer/PrivacyPolicy';
import Terms from './components/footer/Terms';
import Disclaimer from './components/footer/Disclaimer';
import FAQ from './components/footer/FAQ';


class App extends React.Component {
  render() {
    return (
      <div>
        <Header/>
        {/* <Search/> */}
        <Router>
          <Route path='/' exact component={HomePage}/>
          <Route path='/contact' component ={Contact}/>
          <Route path='/about-us' component ={AboutUs}/>
          <Route path='/track-trace' component ={TrackAndTrace}/>
          <Route path='/request-quote' component ={RequestQuote}/>
          <Route path='/choose-us' component ={ChooseUs}/>
          <Route path='/supply-solutions' component ={SupplyChainSolutions}/>
          <Route path='/warehouse-solutions' component ={WarehouseSolutions}/>
          <Route path='/search' component ={Search}/>
          <Route path = '/privacy-policy' component ={PrivacyPolicy}/>
          <Route path = '/terms' component ={Terms}/>
          <Route path = '/disclaimer' component ={Disclaimer}/>
          <Route path = '/faq' component ={FAQ}/>
        </Router>
        <Footer/>
    </div>
    );
  }
}

export default App;
