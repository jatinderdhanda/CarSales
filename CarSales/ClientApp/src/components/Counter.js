import React from "react";
import { useSelector, useDispatch } from "react-redux";
import { ActionTypes } from "../ActionTypes.ts";

const Counter = () => {
  const state = useSelector((state) => state);
  const dispatch = useDispatch();

  const { counter } = {
    ...state,
  };

  return (
    <div>
      <h1>Counter</h1>

      <p>This is a simple example of a React component.</p>

      <p aria-live="polite">
        Current count: <strong>{counter}</strong>
      </p>

      <button
        className="btn btn-primary"
        onClick={() => dispatch({ type: ActionTypes.INCREMENT })}
      >
        Increment
      </button>
    </div>
  );
};

export default Counter;
