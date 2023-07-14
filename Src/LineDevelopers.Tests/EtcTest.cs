using Line.Message.Corporation;

namespace LineDevelopers.Tests
{
    [TestFixture]
    internal class EtcTest : BaseTest
    {
        [Test]
        [Description("https://developers.line.biz/en/docs/partner-docs/line-notification-messages/technical-specs/#phone-number-hashed")]
        public void PhoneNumberTest()
        {
            string phoneNumber = "+818000001234";

            var result = PhoneNumber.EncryptSHA256(phoneNumber);

            That(result, Is.EqualTo("d41e0ad70dddfeb68f149ad6fc61574b9c5780ab7bcb2fba5517771ffbb2409c"));
        }

        [Test]
        public async Task PhoneNumberAsyncTest()
        {
            string phoneNumber = "+818000001234";

            var result = await PhoneNumber.EncryptSHA256Async(phoneNumber);

            That(result, Is.EqualTo("d41e0ad70dddfeb68f149ad6fc61574b9c5780ab7bcb2fba5517771ffbb2409c"));
        }
    }
}
