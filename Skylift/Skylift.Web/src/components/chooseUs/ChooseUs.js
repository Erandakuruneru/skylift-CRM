import React from "react";

class ChooseUs extends React.Component {
  render() {
    return (
      <div>
      <div id="about">
        <section className="why-choose-us d-flex align-items-center py-5">
          <div className="container">
            <div className="row d-flex align-items-center">
              <div className="col-lg-7" data-aos="fade-right">
                <h2 className="py-2 fw-bolder">WHY CHOOSE US<br /></h2>
                <p className="py-2 fw-bolde">
                SKYLIFT 3PL has international experience in providing safe and efficient logistics solutions for B2B
                and B2C operations. We are also one of the most sophisticated 3PL service providers in Sri Lanka
                that utilizes advanced technological solutions and intelligent technologies to expedite operations.
                </p>
                <p className="py-2 fw-bolde">
                Our focus is on robotics, packing, sortation, loading and unloading. Our teams use a best-in-class
                WMS (Warehouse Management System) to optimize productivity. We’re equally invested in data
                science to give you live updates and forecasts about supply coming in and going out.
                </p>
                <p className="py-2 fw-bolde">
                We go beyond day-to-day operations to offer value added services like packing, knitting, labeling,
                tagging, weighing and inspecting.
                </p>

              </div>
              <div
                className="col-lg-5 text-center py-4 py-sm-0"
                data-aos="fade-down"
              >
                <img
                  className="img-fluid"
                  src="./assets/images/chosse-us.jpg"
                  alt="about"
                />
              </div>

            </div>
            <div className="row d-flex align-items-center">
          <div className="col-lg" data-aos="fade-right">
              <p><b>Recognized Expertise</b></p>
                <p className="py-2 fw-bolde">
                Our value chain management systems are proven and functional. Thanks to our expertise in this
                field, we have created reliable models, which allow for significant time and cost savings, using
                innovative digital tools.
                </p>
                <p><b>Safety Policy</b></p>
                <p className="py-2 fw-bolde">
                Our reputation has been built on safety, compliance and a firm commitment to Chain of
                Responsibility. Our goal is Vision ZERO. Zero fatalities. Zero injuries. Zero motor vehicle incidents.
                Zero net emissions. Zero tolerance of unsafe behaviour.
                </p>
                <p><b>Quality Policy</b></p>
                <p className="py-2 fw-bolde">
                Delivering customer satisfaction and continual improvement is the responsibility of every SKYLIFT
                employee. We strive for perfection, providing our services efficiently to the required internal and
                external standards and objectives. We operate our business in a safe, healthy and environmentally
                responsible manner in accordance with all applicable regulations. We accept ownership and
                accountability as individuals and as a global team.
                </p>

              </div>
            </div>
          </div>

        </section>
        </div>
      </div>
    );
  }
}

export default ChooseUs;
