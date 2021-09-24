import React  from 'react';
import Search from '../search/Search';

const Contact = () => {
  return (
  <div>
<section className="contact d-flex align-items-center py-5">
          <div className="container">
            <div className="row d-flex align-items-center">
              <div className="col-lg-7" data-aos="fade-right">
                <h2 className="py-2 fw-bolder">CONTACT <br /></h2>
                <h2 className="py-2 fw-bolder">Send your query</h2>
                <p className="py-2 fw-bolde">
                SKYLIFT 3PL has international experience in providing safe and efficient logistics solutions for B2B
                and B2C operations. We are also one of the most sophisticated 3PL service providers in Sri Lanka
                that utilizes advanced technological solutions and intelligent technologies to expedite operations.
                </p>
                <div className="row" >
                                <div className="col-lg-6">
                                    <div className="form-group py-2">
                                        <input type="text" className="form-control form-control-input" id="exampleFormControlInput1" placeholder="Enter name"/>
                                    </div>                                
                                </div>
                            </div>   
                        <div className="my-3">
            <button className="btn-secondary fw-bolder">Submit</button>
          </div>

              </div>
              <div
                className="col-lg-5 text-center py-4 py-sm-0"
                data-aos="fade-down"
              >
                <img
                  className="img-fluid"
                  src="./assets/images/contact-us.jpg"
                  alt="about"
                />
              </div>

            </div>
          </div>
        </section>
  </div>      
  );
};

export default Contact;
