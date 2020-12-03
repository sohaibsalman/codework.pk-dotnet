import { Button, Grid, TextField, Typography } from "@material-ui/core";
import React, { Component } from "react";

import utilityStyles from "../../../styles/utilityStyles";

import "./login.css";

class Login extends Component {
  state = {};
  render() {
    return (
      <React.Fragment>
        <div className="outer">
          <div className="inner">
            <LoginForm />
          </div>
        </div>
      </React.Fragment>
    );
  }
}

const LoginForm = () => {
  return (
    <Grid container>
      <Grid item md={5} xs={12}>
        <Form />
      </Grid>
      <Grid item md={7} xs={12}>
        <div className="img"></div>
      </Grid>
    </Grid>
  );
};

const Form = () => {
  const util = utilityStyles();
  return (
    <div className="form">
      <Typography variant="h6" className={util.mbHuge}>
        CodeWork.pk
      </Typography>
      <Typography variant="h5" className={util.txtCapitalize}>
        Intelligent Workplace for geeks
      </Typography>
      <Typography color="textSecondary" className={util.mtbTiny}>
        Work Anywhere, Anytime
      </Typography>
      <form>
        <TextField
          label="Username"
          variant="outlined"
          fullWidth
          required
          className={util.mtbTiny}
        />
        <TextField
          label="Email"
          type="email"
          variant="outlined"
          fullWidth
          required
          className={util.mtbTiny}
        />
        <TextField
          label="Password"
          type="password"
          variant="outlined"
          required
          fullWidth
          className={util.mtbTiny}
        />
        <Button
          variant="contained"
          color="primary"
          fullWidth
          size="large"
          className={util.mtbTiny}
        >
          Create Account
        </Button>
      </form>
    </div>
  );
};

export default Login;
