import React, { useEffect, useState } from "react";
import { FunnelFill, CalendarDateFill } from "react-bootstrap-icons";
import { Search } from "react-feather";
import ReactMultiSelectCheckboxes from "react-multiselect-checkboxes";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import AssignmentTable from "./AssignmentTable";
import ISelectOption from "src/interfaces/ISelectOption";
import { Link, useLocation } from "react-router-dom";
import DatePicker from 'react-datepicker';
import {
    ACCSENDING,
    DECSENDING,
    DEFAULT_PAGE_LIMIT,
    DEFAULT_ASSET_SORT_COLUMN_NAME,
} from "src/constants/paging";
import IPagedModel from "src/interfaces/IPagedModel";
//import { cleanUpActionResult, disableAssignment, getAssignmentList, getCategory, getState } from "../reducer";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignmentModel";
import SelectBox from "src/components/SelectBox";

const defaultQuery: IQueryAssignmentModel = {
    search: "",
    page: 1,
    limit: DEFAULT_PAGE_LIMIT,
    assignDate: new Date(),
    sortOrder: ACCSENDING,
    sortColumn: DEFAULT_ASSET_SORT_COLUMN_NAME,
    states: ['1', '2', '3'],
}

const defaultSelectedState: ISelectOption[] = [
    { id: 2, label: "Accepted", value: 1 },
    { id: 3, label: "Waiting for acceptance", value: 2 },

]


const ListAssignment = () => {
    const dispatch = useAppDispatch();
    const { assignments, actionResult } = useAppSelector((state) => state.assignmentReducer);

    const [query, setQuery] = useState(assignments ? { ...defaultQuery, page: assignments.currentPage } : defaultQuery);

    const [search, setSearch] = useState("");
    const [assignedDate, setAssignedDate] = useState("");
    const [selectedState, setSelectedState] = useState(defaultSelectedState);

    const { FilterAssignmentStateOptions } = useAppSelector(state => state.assignmentReducer)

    const handleState = (selected: ISelectOption[]) => {
        if (selected.length === 0) {
            setQuery({
                ...query,
                states: ["ALL"],
                page: 1
            });

            setSelectedState([FilterAssignmentStateOptions[0]]);

            return;
        }

        const selectedAll = selected.find((item) => item.id === 1);

        setSelectedState((prevSelected) => {
            if (!prevSelected.some((item) => item.id === 1) && selectedAll) {
                setQuery({
                    ...query,
                    states: ["ALL"],
                    page: 1
                });

                return [selectedAll];
            }
            const newSelected = selected.filter((item) => item.id !== 1);
            const states = newSelected.map((item) => item.value as string);

            setQuery({
                ...query,
                states,
                page: 1
            });

            return newSelected;
        });
        console.log(query)
    };
    const handleAssignDateChange = (date: Date) => {

    }
    const handleChangeSearch = (e) => {
        e.preventDefault();

        const search = e.target.value;
        setSearch(search);
        console.log(query)
    };

    const handlePage = (page: number) => {
        setQuery({
            ...query,
            page,
        });
        console.log(query)
    };

    const handleSearch = () => {
        setQuery({
            ...query,
            search,
            page: 1
        });
        console.log(query)
    };

    const handleSort = (sortColumn: string) => {
        let sortOrder
        if (query.sortColumn != sortColumn) {
            sortOrder = ACCSENDING
        } else {
            sortOrder = query.sortOrder === ACCSENDING ? DECSENDING : ACCSENDING;
        }
        setQuery({
            ...query,
            sortColumn,
            sortOrder,
        });
    };

    const handleDisable = (id) => {
        // dispatch(disableAssignment({
        //   id: id,
        //   handleResult: (result, message) => {
        //     if (result) {
        //       setQuery({ ...defaultQuery });
        //     }
        //   }
        // }))
    };

    const fetchData = () => {
        // dispatch(getAssignmentList(query))
    };

    useEffect(() => {
        // dispatch(cleanUpActionResult())
        // fetchData()
    }, [query]);

    useEffect(() => {
        // dispatch(getAssignmentList({...defaultQuery}))
        // dispatch(getState())
    }, []);

    return (
        <>
            <div className="primaryColor text-title intro-x ">Asset List</div>

            <div>
                <div className="d-flex mb-5 intro-x">
                    <div className="d-flex align-items-center w-md mr-5">
                        <div className="button">
                            <div className="filter-state">
                                <SelectBox
                                    options={FilterAssignmentStateOptions}
                                    placeholderButtonLabel="State"
                                    value={selectedState}
                                    onChange={handleState} />
                            </div>
                        </div>
                    </div>
                    <div className="d-flex align-items-center w-md mr-5">
                        <div className="button">
                            <div className="col">
                                <div className="d-flex align-items-center w-100">
                                    <DatePicker
                                        className={"form-control  w-100 "}
                                        value={assignedDate}
                                        onChange={handleAssignDateChange}
                                        maxDate={new Date()} />
                                </div>
                                <div className="" style={{ position: 'absolute', right: 30, top: 4, pointerEvents: "none" }}>
                                    <CalendarDateFill />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="d-flex align-items-center w-ld ml-auto mr-2">
                        <div className="input-group">
                            <input
                                onChange={handleChangeSearch}
                                value={search}
                                type="text"
                                className="input-search  form-control"
                            />
                            <span onClick={handleSearch} className=" search-icon p-1 pointer">
                                <Search />
                            </span>
                        </div>
                    </div>

                    <div className="d-flex align-items-center ml-3">
                        <Link to="/asset/create" type="button" className="btn btn-danger">
                            Create new asset
                        </Link>
                    </div>
                </div>
                {(() => {
                    if (assignments?.totalItems == 0) {
                        return (
                            <h5 className="not-data-found">No data found</h5>
                        )
                    } else {
                        return (
                            <>
                                <AssignmentTable
                                    assignments={assignments}
                                    result={actionResult}
                                    handlePage={handlePage}
                                    handleSort={handleSort}
                                    handleDisable={handleDisable}
                                    sortState={{
                                        columnValue: query.sortColumn,
                                        orderBy: query.sortOrder,
                                    }}
                                    fetchData={fetchData}
                                />
                            </>
                        )
                    }
                })()}
            </div>
        </>
    );
};

export default ListAssignment;