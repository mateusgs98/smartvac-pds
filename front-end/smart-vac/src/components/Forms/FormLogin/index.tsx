import { Input } from "@/components/FormElements/Input";
import { FormContainer } from "@/components/Forms/FormLogin/styles";
import { Form, Formik } from "formik";
import { Button } from "react-bootstrap";
import * as Yup from 'yup';

interface FormLoginProps {
    onSubmit: (data: object) => void;
}

export default function FormLogin(props: FormLoginProps) {
    const initialValues = {
        email: '',
        password: '',
    };

    const validationSchema = Yup.object().shape({
        email: Yup.string().email('Digite um e-mail válido').required('Campo obrigatório'),
        password: Yup.string().required('Campo obrigatório'),
    });

    return (
        <>
            <Formik
                initialValues={initialValues}
                validationSchema={validationSchema}
                onSubmit={props.onSubmit}
            >
                {({ isSubmitting }) => (
                    <Form>
                        <FormContainer>
                            <h2>Login</h2>
                            <Input name="email" label="E-mail" />
                            <Input name="password" type="password" label="Senha" />
                            <div className="extra">
                                <a href="/register">Criar Conta</a>
                                <Button variant="default" type="submit" disabled={isSubmitting}>
                                    Entrar
                                </Button>
                            </div>
                        </FormContainer>
                    </Form>
                )}
            </Formik >
        </>
    );

}