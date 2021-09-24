import React from "react";

const Test = () => {

  return (
    <div >
        {/* <section className="about d-flex align-items-end text-light py-5 back-ground-black"> */}
          <div className="container">
      <div className="popover-menu">
      <ul className="popover-menu__list">
        <li className="popover-menu__item">
          <a
            href="#"
            className="popover-menu__link popover-menu__link--has-child   menu-item menu-item-type-custom menu-item-object-custom menu-item-has-children "
          >
            Capabilities{" "}
            <span className="popover-menu__link-more"></span>{" "}
            <span className="popover-menu__angle"></span>{" "}
          </a>
          <div className="popover-menu__child">
          </div>
        </li>
      </ul>
      <div className="popover-menu__image">

        <img src="./assets/images/feature-image.jpg"/>
        <div className="popover-menu__follow">
          <strong className="popover-menu__follow-heading">
            Follow
          </strong>
        </div>
      </div>
    </div>

    </div>
    {/* </section> */}

        </div>









  );
};

export default Test;