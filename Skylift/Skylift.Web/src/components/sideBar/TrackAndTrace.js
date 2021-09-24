import React from "react";

const TrackAndTrace = () => {
  return (
    <div>
      <section className="contact py-5 d-flex align-items-center" id="header">
        <div
          className="container py-5"
        >
          <h2 className="py-2 fw-bolder">Track &amp; Trace </h2>
          <div className="d-flex align-items-center">
            <input
              type="text"
              id={'Track'}
              name={'Track'}
              maxLength={100}
            //   onChange={onChange}
              required={false}
            />
          </div>
          <div className="my-3">
            <button className = 'btn-secondary fw-bolder'>Search</button>
          </div>
        </div>
      </section>
    </div>
  );
};
export default TrackAndTrace;
