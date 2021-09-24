import React from "react";
import AboutUs from '../aboutUs/AboutUs'
import * as constants from '../../constants';

class HomePage extends React.Component {
  constructor(props, context) {
    super(props, context);
    this.navigateToSolutions = this.navigateToSolutions.bind(this);
  }

  navigateToSolutions(event) {
    let navURL = constants.URL_WAREHOUSE_SOLUTIONS;
    window.location = navURL;
  }
  render() {
    return (
      <div>
        <section className="home py-5 d-flex align-items-center" id="header">
          <div className="head-wrapper text-light py-5 pl-1" data-aos="fade-right">
            <h1 className="headline fs-1 fw-bolder">
               DRIVING THE<span className="home_text"> FUTURE</span> OF LOGISTICS
            </h1>
            <div className="my-3 py-4 fw-bolder">
                <button className="btn-secondary  text-light" onClick ={this.navigateToSolutions}>Solutions</button>

            </div>
          </div>
        </section>
        <div className="home-5-bg">
        <div className="d-flex head-wrapper  text-light">
              <h1 className="headline fs-1 fw-bolder"  data-aos="fade-down">
                OUR CAPABILITIES
                
            </h1>
        </div>
        </div>


                


              {/* </div> */}
         {/* <AboutUs /> */}
         <section className="home-1 d-flex align-items-start  text-black-100  ">
          <div className="container">

          <div className="row d-flex py-3 align-items-start">
            <div className="row" data-aos="zoom-in">
                <div className="col-lg-4">
                    <div className="card bg-transparent px-4 min-height-1">
                        <h4 className="py-2 fw-bolder">Warehousing and Distribution</h4>
                        {/* <p className="py-3">Complex, custom to no-frills warehousing</p> */}
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>Specialized Cargo Handling</p>
                        </div>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>Freight Consolidation & Deconsolidation</p>
                        </div>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>Complex, Custom to no-frills Warehousing</p>
                        </div>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>Value Added Services</p>
                        </div>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>In House BOI & Customs Verification</p>
                        </div>
                    </div>  
                </div>

                <div className="col-lg-4">
                    <div className="card bg-transparent px-4 min-height-1">
                        <h4 className="py-2 fw-bolder">Transport & Freight</h4>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>Transport Management Portal</p>
                        </div>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>Largest Managed Fleet</p>
                        </div>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>RFID Technology</p> 
                            &nbsp;
                        </div>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>Varied fleet of 40ft, 20ft containers to 16.5ft, 14.5ft LCLS</p>
                        </div>
                    </div>  
                </div>
                
                <div className="col-lg-4">
                    <div className="card bg-transparent px-4 min-height-1">
                        <h4 className="py-2 fw-bolder">Value Added Services</h4>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>Pick, Pack and Knitting</p>
                        </div>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>Tagging and Packing</p>
                        </div>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>Layout and Inspection</p>
                        </div>
                        <div className="block d-flex align-items-center">
                            <p className="pe-2"><i className="far fa-check-circle fa-1x"></i></p>
                            <p>Carton Mixing</p>
                        </div>
                    </div>  
                </div>
            </div>
            </div>
            </div>
            </section>



            <section className ="home-2 d-flex align-items-center py-1">
        <div className="container  text-black-100">
            <div className="row">
                <div className="col-lg-6 d-flex align-items-center aos-init aos-animate" data-aos="fade-right">
                    <img className="img-fluid" src="./assets/images/work.jpg" alt="work"/>        
                </div>
                <div className="col-lg-5 d-flex align-items-center px-4 py-3 aos-init aos-animate" data-aos="">
                    <div className="row">
                        <div className="text-center text-lg-start py-4 pt-lg-0">
                            <h2 className="py-2 fw-bolder">WE ARE IMPROVING SUPPLY CHAIN EVERY DAY</h2>
                            <p className="fw-bolder">Lorem ipsum dolor sit amet consectetur, adipisicing elit. Dignissimos dicta mollitia totam explicabo obcaecati quia laudantium repudiandae.</p>
                        </div>
                        <div className="container aos-init aos-animate" data-aos="fade-up">
                            <div className="row g-4">
                                <div className="col-6 text-start">
                                    <i className="fas fa-briefcase fa-2x text-start"></i>
                                    <h2 >
                                    <span className="purecounter" data-purecounter-start="0" data-purecounter-end="1258" class="purecounter">1258</span>
                                    </h2>
                                    <p className="fw-bolder">WAREHOUSING CAPACITY</p>
                                </div>
                                <div className="col-6">
                                    <i className="fas fa-award fa-2x"></i>
                                    <h2>
                                    <span className="purecounter" data-purecounter-start="0" data-purecounter-end="150" class="purecounter">150</span>
                                    </h2>
                                    <p className="fw-bolder">LEADING COMPANIES</p>

                                </div>
                                <div className="col-6">
                                    <i className="fas fa-users fa-2x"></i>
                                    <h2 >
                                    <span className="purecounter" data-purecounter-start="0" data-purecounter-end="1255" class="purecounter">1255</span>
                                    </h2>
                                    <p className="fw-bolder">VEHICLE FLEET</p>
                                </div>
                                <div className="col-6">
                                    <i className="fas fa-clock fa-2x"></i>
                                    <h2>
                                    <span className="purecounter" data-purecounter-start="0" data-purecounter-end="1157" class="purecounter">1157</span>
                                    </h2>
                                    <p className="fw-bolder">EMPLOYEES</p>
                                </div>
                            </div>
                        </div> 
                    </div> 
                </div>
            </div> 
        </div> 
    </section>





    <section className="home-4 d-flex align-items-center  text-black-100   py-5">
          <div className="container">
            <div className="row d-flex align-items-center">
              <div className="col-lg-7" data-aos="fade-right">
              <p className="fw-bolder">Leading the way</p>
                <h2 className="py-2 fw-bolder">A COMMITMENT TO EFFICIENT AND RESPONSIVE SUPPLY CHAINS</h2>
                <p className="py-2 fw-bolder">
                if you require supply chain solutions SKYLIFT has the expertise to design innovative, 
                marketleading supply chain solutions.
                </p>  
                        <div className="my-3 py-5 fw-bolder">
            <button className="btn-secondary  text-black-100">Warehouse Solutions</button>
            &nbsp;
            <button className="btn-secondary  text-black-100">Value Added Services</button>
          </div>

              </div>
              <div
                className="col-lg-5 text-center py-4 py-sm-0"
                data-aos="fade-left"
              >
                <img
                  className="img-fluid"
                  src="./assets/images/trucks.png"
                  alt="about"
                />
              </div>

            </div>
          </div>
        </section>

        <section className="home-3 home-bg img-fluid contact d-flex align-items-center  text-light">
          <div className="container">
            <div className="row d-flex align-items-center">
              <div className="col-lg-7" data-aos="fade-right">
                <p className="fw-bolder">Leading the way</p>
                <h2 className="py-2 fw-bolder">A COMMITMENT TO EFFICIENT AND RESPONSIVE SUPPLY CHAINS</h2>
                <p className="py-2 fw-bolder">
                if you require supply chain solutions SKYLIFT has the expertise to design innovative, 
                marketleading supply chain solutions.
                </p>  
                        <div className="my-3 py-5 fw-bolder">
            <button className="btn-secondary  text-light">Warehouse Solutions</button>
            &nbsp;
            <button className="btn-secondary text-light">Value Added Services</button>
          </div>

              </div>

            </div>
          </div>
        </section>













      </div>
    );
  }
}

export default HomePage;
