--
-- PostgreSQL database dump
--

-- Dumped from database version 13.6
-- Dumped by pg_dump version 13.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: guest; Type: TABLE; Schema: public; Owner: sanirasu_admin
--

CREATE TABLE public.guest (
    guest_id bigint NOT NULL,
    guest_name character varying NOT NULL,
    guest_details character varying NOT NULL,
    guest_city character varying,
    guest_country character varying
);


ALTER TABLE public.guest OWNER TO sanirasu_admin;

--
-- Name: guest_guest_id_seq; Type: SEQUENCE; Schema: public; Owner: sanirasu_admin
--

CREATE SEQUENCE public.guest_guest_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.guest_guest_id_seq OWNER TO sanirasu_admin;

--
-- Name: guest_guest_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sanirasu_admin
--

ALTER SEQUENCE public.guest_guest_id_seq OWNED BY public.guest.guest_id;


--
-- Name: rooms; Type: TABLE; Schema: public; Owner: sanirasu_admin
--

CREATE TABLE public.rooms (
    room_id bigint NOT NULL,
    room_type integer NOT NULL,
    room_no integer NOT NULL,
    staff_id bigint NOT NULL,
    room_rate bigint
);


ALTER TABLE public.rooms OWNER TO sanirasu_admin;

--
-- Name: rooms_room_id_seq; Type: SEQUENCE; Schema: public; Owner: sanirasu_admin
--

CREATE SEQUENCE public.rooms_room_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.rooms_room_id_seq OWNER TO sanirasu_admin;

--
-- Name: rooms_room_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sanirasu_admin
--

ALTER SEQUENCE public.rooms_room_id_seq OWNED BY public.rooms.room_id;


--
-- Name: rooms_staff_id_seq; Type: SEQUENCE; Schema: public; Owner: sanirasu_admin
--

CREATE SEQUENCE public.rooms_staff_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.rooms_staff_id_seq OWNER TO sanirasu_admin;

--
-- Name: rooms_staff_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sanirasu_admin
--

ALTER SEQUENCE public.rooms_staff_id_seq OWNED BY public.rooms.staff_id;


--
-- Name: roomservicestaff; Type: TABLE; Schema: public; Owner: sanirasu_admin
--

CREATE TABLE public.roomservicestaff (
    staff_id bigint NOT NULL,
    staff_name character varying NOT NULL,
    staff_address character varying NOT NULL,
    contact_number bigint NOT NULL,
    gender character varying NOT NULL,
    staff_zip_code bigint
);


ALTER TABLE public.roomservicestaff OWNER TO sanirasu_admin;

--
-- Name: roomservicestaff_staff_id_seq; Type: SEQUENCE; Schema: public; Owner: sanirasu_admin
--

CREATE SEQUENCE public.roomservicestaff_staff_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.roomservicestaff_staff_id_seq OWNER TO sanirasu_admin;

--
-- Name: roomservicestaff_staff_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sanirasu_admin
--

ALTER SEQUENCE public.roomservicestaff_staff_id_seq OWNED BY public.roomservicestaff.staff_id;


--
-- Name: stayschedule; Type: TABLE; Schema: public; Owner: sanirasu_admin
--

CREATE TABLE public.stayschedule (
    stayschedule_id bigint NOT NULL,
    check_in timestamp with time zone,
    check_out time with time zone,
    room_id bigint NOT NULL,
    guest_id bigint NOT NULL
);


ALTER TABLE public.stayschedule OWNER TO sanirasu_admin;

--
-- Name: stayschedule_stayschedule_id_seq; Type: SEQUENCE; Schema: public; Owner: sanirasu_admin
--

CREATE SEQUENCE public.stayschedule_stayschedule_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.stayschedule_stayschedule_id_seq OWNER TO sanirasu_admin;

--
-- Name: stayschedule_stayschedule_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sanirasu_admin
--

ALTER SEQUENCE public.stayschedule_stayschedule_id_seq OWNED BY public.stayschedule.stayschedule_id;


--
-- Name: guest guest_id; Type: DEFAULT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.guest ALTER COLUMN guest_id SET DEFAULT nextval('public.guest_guest_id_seq'::regclass);


--
-- Name: rooms room_id; Type: DEFAULT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.rooms ALTER COLUMN room_id SET DEFAULT nextval('public.rooms_room_id_seq'::regclass);


--
-- Name: rooms staff_id; Type: DEFAULT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.rooms ALTER COLUMN staff_id SET DEFAULT nextval('public.rooms_staff_id_seq'::regclass);


--
-- Name: roomservicestaff staff_id; Type: DEFAULT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.roomservicestaff ALTER COLUMN staff_id SET DEFAULT nextval('public.roomservicestaff_staff_id_seq'::regclass);


--
-- Name: stayschedule stayschedule_id; Type: DEFAULT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.stayschedule ALTER COLUMN stayschedule_id SET DEFAULT nextval('public.stayschedule_stayschedule_id_seq'::regclass);


--
-- Data for Name: guest; Type: TABLE DATA; Schema: public; Owner: sanirasu_admin
--

COPY public.guest (guest_id, guest_name, guest_details, guest_city, guest_country) FROM stdin;
1	surender	hyderabad	\N	\N
4	sanjay	gandhinagar	chennai	india
\.


--
-- Data for Name: rooms; Type: TABLE DATA; Schema: public; Owner: sanirasu_admin
--

COPY public.rooms (room_id, room_type, room_no, staff_id, room_rate) FROM stdin;
5	2	9	7	\N
2	1	10	7	10000
\.


--
-- Data for Name: roomservicestaff; Type: TABLE DATA; Schema: public; Owner: sanirasu_admin
--

COPY public.roomservicestaff (staff_id, staff_name, staff_address, contact_number, gender, staff_zip_code) FROM stdin;
7	surya	bangalore	12345679	male	\N
8	randeep	srnagar	8985887652	male	500001
\.


--
-- Data for Name: stayschedule; Type: TABLE DATA; Schema: public; Owner: sanirasu_admin
--

COPY public.stayschedule (stayschedule_id, check_in, check_out, room_id, guest_id) FROM stdin;
1	\N	\N	5	1
9	2016-10-01 13:56:26.832+05:30	19:56:26.832+05:30	5	1
\.


--
-- Name: guest_guest_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sanirasu_admin
--

SELECT pg_catalog.setval('public.guest_guest_id_seq', 1, false);


--
-- Name: rooms_room_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sanirasu_admin
--

SELECT pg_catalog.setval('public.rooms_room_id_seq', 1, false);


--
-- Name: rooms_staff_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sanirasu_admin
--

SELECT pg_catalog.setval('public.rooms_staff_id_seq', 1, false);


--
-- Name: roomservicestaff_staff_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sanirasu_admin
--

SELECT pg_catalog.setval('public.roomservicestaff_staff_id_seq', 1, false);


--
-- Name: stayschedule_stayschedule_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sanirasu_admin
--

SELECT pg_catalog.setval('public.stayschedule_stayschedule_id_seq', 1, false);


--
-- Name: guest guest_pkey; Type: CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.guest
    ADD CONSTRAINT guest_pkey PRIMARY KEY (guest_id);


--
-- Name: rooms rooms_pkey; Type: CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.rooms
    ADD CONSTRAINT rooms_pkey PRIMARY KEY (room_id);


--
-- Name: roomservicestaff roomservicestaff_pkey; Type: CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.roomservicestaff
    ADD CONSTRAINT roomservicestaff_pkey PRIMARY KEY (staff_id);


--
-- Name: stayschedule stayschedule_pkey; Type: CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.stayschedule
    ADD CONSTRAINT stayschedule_pkey PRIMARY KEY (stayschedule_id);


--
-- Name: stayschedule guest_id; Type: FK CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.stayschedule
    ADD CONSTRAINT guest_id FOREIGN KEY (guest_id) REFERENCES public.guest(guest_id) NOT VALID;


--
-- Name: stayschedule room_id; Type: FK CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.stayschedule
    ADD CONSTRAINT room_id FOREIGN KEY (room_id) REFERENCES public.rooms(room_id) NOT VALID;


--
-- Name: rooms staff_id; Type: FK CONSTRAINT; Schema: public; Owner: sanirasu_admin
--

ALTER TABLE ONLY public.rooms
    ADD CONSTRAINT staff_id FOREIGN KEY (staff_id) REFERENCES public.roomservicestaff(staff_id) NOT VALID;


--
-- PostgreSQL database dump complete
--

