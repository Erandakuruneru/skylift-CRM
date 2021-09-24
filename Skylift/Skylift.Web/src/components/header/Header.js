import React, { Component } from "react";
import * as constants from "../../constants";
import Search from "../search/Search";
import TrackAndTrace from "../sideBar/TrackAndTrace";
// import Dropdown from './Dropdown';

class Header extends Component {
  constructor(props, context) {
    super(props, context);
    this.state = {
      isSearch: false,
    };
    this.onClickSearch = this.onClickSearch.bind(this);
    this.onClickClose = this.onClickClose.bind(this);
  }

  onClickSearch(event) {
    document.body.classList.remove('menu-active');
  }

  onClickClose(event) {
    document.body.classList.remove('menu-active');
  }
  

  render() {
    let className = this.state.isSearch
      ? "animate__animated animate__bounceInLeft popover-menu-active "
      : "popover-menu";

    let classNames = this.state.isSearch
      ? "hamburger js-hamburger"
      : "hamburger js-hamburger";

    let homeNavUrl = constants.URL_HOME;
    let contactNavUrl = constants.URL_CONTACT;
    let aboutUsNavUrl = constants.URL_ABOUT_US;
    let whyChooseUsNavUrl = constants.URL_CHOOSE_US;
    let supplySolutionsNavUrl = constants.URL_SUPPLY_SOLUTIONS;
    let wareshouseSolutionsNavUrl = constants.URL_WAREHOUSE_SOLUTIONS;

    return (
      <div>
        <nav
          id="navbar"
          className="navbar navbar-expand-lg fixed-top navbar-dark"
          aria-label="Main navigation"
        >
          <div className="head-wrapper">
            <a href={homeNavUrl}>
              <img
                className="logo-image"
                src="./assets/images/skyliftlogo.jpeg"
                alt="about"
              />
            </a>

            <button
              className="navbar-toggler p-0 border-0"
              type="button"
              id="navbarSideCollapse"
              aria-label="Toggle navigation"
              onClick= {this.onClickSearch}
            >
              <span className="navbar-toggler-icon"></span>
            </button>

            <div
              className="navbar-collapse offcanvas-collapse"
              id="navbarsExampleDefault"
            >
              <ul className="navbar-nav ms-auto navbar-nav-scroll">
                <li className="nav-item">
                  <a className="nav-link" aria-current="page" href={homeNavUrl}>
                    Home
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href={aboutUsNavUrl}>
                    About
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href={whyChooseUsNavUrl}>
                    Why Choose Us
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href={contactNavUrl}>
                    Contact
                  </a>
                </li>
                <li class="nav-item dropdown" aria-expanded="false">
                  <a
                    class="nav-link dropdown-toggle"
                    id="dropdown01"
                    data-bs-toggle="dropdown"
                    aria-expanded="false"
                    href="#"
                  >
                    Solutions
                  </a>
                  <ul class="dropdown-menu" aria-labelledby="dropdown01">
                    <li>
                      <a class="dropdown-item" href={supplySolutionsNavUrl}>
                        Supply Chain Solutions
                      </a>
                    </li>
                    <li>
                      <div class="dropdown-divider"></div>
                    </li>
                    <li>
                      <a class="dropdown-item" href={wareshouseSolutionsNavUrl}>
                        Warehouse and Distribution
                      </a>
                    </li>
                  </ul>
                </li>
              </ul>
            </div>
          </div>
        </nav>
        <div className="side-navbar">
          <ul className="side-navbar-menu text-center">
            {/* <li>
              <a href="#">
                <div>
                  <i className="fas fa-search"></i>
                </div>
                <div className="nav-name">Search</div>
              </a>
            </li> */}
            <li>
              <a href={"#"}>
                  <i className="fas fa-search hamburger js-hamburger">
                  </i>
              </a>
            </li>


           <li>
              <a href="#">
                <div>
                  <i className="fas fa-map-marked-alt"></i>
                </div>
                <div className="nav-name"> Track and Trace</div>
              </a>
            </li>

            <li>
              <a href="#">
                <div>
                  <i className="fas fa-file-alt"></i>
                </div>
                <div className="nav-name">  Request a quote</div>
              </a>
            </li>

            <li>
              <a href="#">
                <div>
                  <i className="fas fa-user"></i>
                </div>
                <div className="nav-name">  Customer resources</div>
              </a>
            </li>
            <li>
              <a href="#">
                <div>
                  <i className="fas fa-hands-helping"></i>
                </div>
                <div className="nav-name">  Join us</div>
              </a>
            </li>



          </ul>
        </div>

        <div className="popover-menu">

          <ul className="popover-menu__list">
            
          {/* <div className="btn-close">
                   <button onClick={this.onClickClose}>
                   <i class="fas fa-window-close"></i>
                  </button>
                </div> */}



          <h2 className="py-2 fw-bolder">Track &amp; Trace </h2>
                          <div className="row" >
                                <div className="col-lg-6">
          <div class="form-group py-2">
            <input type="text" class="form-control form-control-input" 
            id="exampleFormControlInput1" 
            
            placeholder="Enter the code"/></div> </div></div>
          <div className="my-3">
          <button className = 'btn-secondary fw-bolder'>Search</button>
          </div>
          </ul>
          <div className="popover-menu__image">
            <img src="./assets/images/feature-image.jpg" />
          </div>
        </div>
      </div>
    );
  }
}

export default Header;
