import React, { useState } from "react";
import { useFormik } from "formik";
import * as Yup from "yup";
import { Button, Grid, TextField, Typography } from "@material-ui/core";
import { Link } from "react-router-dom";

import utilityStyles from "../../../styles/utilityStyles";

import "./signup.css";

const Signup = () => {
  return (
    <React.Fragment>
      <div className="signup__outer">
        <div className="layer"></div>
        <div className="inner">
          <SignupForm />
        </div>
      </div>
    </React.Fragment>
  );
};

const SignupForm = () => {
  const util = utilityStyles();
  return (
    <React.Fragment>
      <Grid container>
        <Grid item md={7} xs={12}>
          <div className="signup__img"></div>
        </Grid>
        <Grid item md={5} xs={12}>
          {/* Form Header */}
          <div className="form">
            <Typography variant="h6" className={util.mbHuge}>
              <strong>CodeWork.pk</strong>
            </Typography>
            <Typography variant="h5" className={util.txtCapitalize}>
              Intelligent Workplace for geeks
            </Typography>
            <Typography color="textSecondary" className={util.mtbTiny}>
              Work Anywhere, Anytime!
            </Typography>
            {/* Form Body */}
            <Form />
          </div>
        </Grid>
      </Grid>
    </React.Fragment>
  );
};

const Form = () => {
  const util = utilityStyles();
  const formik = useFormik({
    initialValues: {
      email: "",
      username: "",
      password: "",
    },
    validationSchema: Yup.object({
      username: Yup.string().required("Username is required!"),
      password: Yup.string().required("Pasword is required!"),
    }),
    onSubmit: async (values) => {},
  });
  return (
    <form onSubmit={formik.handleSubmit}>
      <TextField
        id="email"
        label="Email"
        className={util.mtbTiny}
        value={formik.values.email}
        onChange={formik.handleChange}
        onBlur={formik.handleBlur}
        helperText={formik.touched.email ? formik.errors.email : ""}
        error={formik.touched.email && Boolean(formik.errors.email)}
        variant="outlined"
        fullWidth
      />
      <TextField
        id="username"
        label="Username"
        className={util.mtbTiny}
        value={formik.values.username}
        onChange={formik.handleChange}
        onBlur={formik.handleBlur}
        helperText={formik.touched.username ? formik.errors.username : ""}
        error={formik.touched.username && Boolean(formik.errors.username)}
        variant="outlined"
        fullWidth
      />
      <TextField
        id="password"
        label="Password"
        type="password"
        className={util.mtbTiny}
        value={formik.values.password}
        onChange={formik.handleChange}
        onBlur={formik.handleBlur}
        helperText={formik.touched.password ? formik.errors.password : ""}
        error={formik.touched.password && Boolean(formik.errors.password)}
        variant="outlined"
        fullWidth
      />
      <Button
        variant="contained"
        color="primary"
        fullWidth
        size="large"
        className={util.mtbTiny}
        type="submit"
      >
        Create Account
      </Button>
      <Typography>
        Already have an account? <Link to="/login">Login</Link>
      </Typography>
    </form>
  );
};

export default Signup;
