import { useField } from "formik";
import React, { InputHTMLAttributes } from "react";
import { Dropdown, DropdownButton } from "react-bootstrap";
import ISelectOption from "src/interfaces/ISelectOption";

type InputFieldProps = InputHTMLAttributes<HTMLInputElement> & {
  label: string,
  name: string,
  isrequired?: boolean,
  options: ISelectOption[],
  notvalidate?: boolean,
};

const DropDownSelectFeild: React.FC<InputFieldProps> = (props) => {

  const [field, { error, touched, value }, { setValue, setTouched }] = useField(props);

  const { name, options, label, isrequired, notvalidate } = props;

  const handleChange = (e) => {
    setValue(e.target.value)
  };
  const handleTouched = () => {
    setTouched(true);
    console.log(touched, error)
  }
  const validateClass = () => {
    if (touched && error) return 'is-invalid';
    if (notvalidate) return '';
    if (touched) return 'is-valid';

    return '';
  };


  return (
    <>
      <div className="dropdown-select mb-3 row">
        <label className="col-4 col-form-label d-flex">
          {label}
          {isrequired && (
            <div className="invalid ml-1">*</div>
          )}
        </label>

        <div className="col">
          {/* <select disabled={props.disabled} style={{ background: "none" }} className={`custom-select ${validateClass()}`} onClick={handleTouched} onChange={handleChange}>
            <option selected hidden></option>
            {
              options.map(({ id, label: optionLabel, value: optionValue }) => (
                <option key={id} value={optionValue} selected={optionValue === value}>
                  {optionLabel}
                </option>
              ))
            }
          </select> */}
          <DropdownButton title="Dropdown button">
            {options.map(option=>(
              <Dropdown.Item key={option.id}>{option.label}</Dropdown.Item>
            ))}
          </DropdownButton>

          {error && touched && (
            <div className='invalid'>{error}</div>
          )}
        </div>
      </div>
    </>
  );
};

export default DropDownSelectFeild;
