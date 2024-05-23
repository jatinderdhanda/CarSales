import { ActionTypes } from "./ActionTypes.ts";
import { InitState } from "./initialState";
const rootReducer = (state= InitState, { type, payload }) => {
  switch (type) {
    case ActionTypes.UPDATE_MODEL:
      return {
        ...state,
        isLoading: false,
        Model: payload.Model,
      };
    case ActionTypes.INCREMENT:
      return {
        ...state,
        counter: state.counter + 1,
      };
    default:
      return state;
  }
};

export default rootReducer;
