import React from "react";

const RequestQuote = () => {
  return (
    <div>
      <section className="contact py-5 d-flex align-items-center" id="header">
        <div
          className="container text-light py-5 aos-init aos-animate"
          data-aos="fade-right"
        >
          <h1 className="headline">Request a Quote</h1>

          <div className="row">
            <div className="col-lg-6">
              <div className="form-group py-2">
                <label>
                    Company Name
                </label>
                <input
                  className="form-control form-control-input"
                  type="text"
                  id={"Track"}
                  name={"Track"}
                  maxLength={100}
                  //   onChange={onChange}
                  required={false}
                />
              </div>
                            <div className="form-group py-2">
                            <label>
                    Service Type
                </label>
                <input
                  className="form-control form-control-input"
                  type="text"
                  id={"Track"}
                  name={"Track"}
                  maxLength={100}
                  //   onChange={onChange}
                  required={false}
                />
              </div>
            </div>
          </div>
          <div className="d-flex align-items-center">
            <input
              className="form-control form-control-input"
              type="text"
              id={"Track"}
              name={"Track"}
              maxLength={100}
              //   onChange={onChange}
              required={false}
            />
          </div>
          <div className="my-3">
            <button className="btn-secondary text-light">Save</button>
          </div>
        </div>
      </section>
    </div>
  );
};
export default RequestQuote;
