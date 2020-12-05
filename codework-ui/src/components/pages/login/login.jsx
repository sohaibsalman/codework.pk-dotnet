import React, { useState } from "react";
import { useFormik } from "formik";
import * as Yup from "yup";
import { Button, Grid, TextField, Typography } from "@material-ui/core";
import Alert from "@material-ui/lab/Alert";

import { login } from "../../../services/authService";

import utilityStyles from "../../../styles/utilityStyles";

import "./login.css";

const Login = () => {
  return (
    <React.Fragment>
      <div className="outer">
        <div className="layer"></div>
        <div className="inner">
          <LoginForm />
        </div>
      </div>
    </React.Fragment>
  );
};

const LoginForm = () => {
  const util = utilityStyles();
  return (
    <Grid container>
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
      <Grid item md={7} xs={12}>
        <div className="img"></div>
      </Grid>
    </Grid>
  );
};

const Form = () => {
  const util = utilityStyles();
  const [error, setError] = useState(null);
  const formik = useFormik({
    initialValues: {
      username: "",
      password: "",
    },
    validationSchema: Yup.object({
      username: Yup.string().required("Username is required!"),
      password: Yup.string().required("Pasword is required!"),
    }),
    onSubmit: async (values) => {
      try {
        await login("useraccount", values.username, values.password);
      } catch (ex) {
        if (ex.response && ex.response.status === 400) {
          setError(ex.response.data);
        }
      }
    },
  });
  return (
    <form onSubmit={formik.handleSubmit}>
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
      {error && <Alert severity="error">{error}</Alert>}
      <Button
        variant="contained"
        color="primary"
        fullWidth
        size="large"
        className={util.mtbTiny}
        type="submit"
      >
        Login
      </Button>
      <Typography>
        Dont have an account? <a href="#">Sign Up</a>{" "}
      </Typography>
    </form>
  );
};

export default Login;
